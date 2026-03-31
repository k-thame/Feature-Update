using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace ThameJordan25SU233x
{
    internal static class DatabaseInitializer
    {
        // Creates SmolTech.db on first launch; migrates existing databases
        public static void EnsureCreated()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SmolTech", "SmolTech.db");
            string sqlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CreateDatabase_SQLite.sql");
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath));

            // Database already exists — run migration to add any new tables
            if (File.Exists(dbPath)) { EnsureMigrated(dbPath); return; }

            // SQL script must be in the same folder as the .exe
            if (!File.Exists(sqlPath))
            {
                MessageBox.Show("Database schema file not found:\n" + sqlPath, "Setup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string script = File.ReadAllText(sqlPath);

                
                script = Regex.Replace(script, @"--[^\r\n]*", "");

                using (var cn = new SqliteConnection($"Data Source={dbPath};"))
                {
                    cn.Open();

                    // Split on semicolons to get individual statements
                    string[] statements = script.Split(';');
                    foreach (string raw in statements)
                    {
                        string statement = raw.Trim();
                        if (string.IsNullOrWhiteSpace(statement)) continue;

                        using (var cmd = cn.CreateCommand())
                        {
                            cmd.CommandText = statement;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Failed to create local database:\n\n" + ex.Message, "Database Setup Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Adds any new tables that may be missing from an existing database
        private static void EnsureMigrated(string dbPath)
        {
            string[] migrations = new[]
            {
                @"CREATE TABLE IF NOT EXISTS Favorites (
                    FavoriteID  INTEGER PRIMARY KEY AUTOINCREMENT,
                    PersonID    INTEGER NOT NULL REFERENCES Person(PersonID),
                    InventoryID INTEGER NOT NULL REFERENCES Inventory(InventoryID),
                    DateAdded   TEXT    NOT NULL DEFAULT (datetime('now')),
                    UNIQUE(PersonID, InventoryID)
                )",
                @"CREATE TABLE IF NOT EXISTS ReorderRequests (
                    RequestID   INTEGER PRIMARY KEY AUTOINCREMENT,
                    PersonID    INTEGER NOT NULL REFERENCES Person(PersonID),
                    RequestDate TEXT    NOT NULL DEFAULT (datetime('now')),
                    Status      INTEGER NOT NULL DEFAULT 0,
                    Notes       TEXT
                )",
                @"CREATE TABLE IF NOT EXISTS ReorderRequestItems (
                    RequestItemID INTEGER PRIMARY KEY AUTOINCREMENT,
                    RequestID     INTEGER NOT NULL REFERENCES ReorderRequests(RequestID),
                    InventoryID   INTEGER NOT NULL REFERENCES Inventory(InventoryID),
                    Quantity      INTEGER NOT NULL DEFAULT 1
                )"
            };

            try
            {
                using (var cn = new SqliteConnection($"Data Source={dbPath};"))
                {
                    cn.Open();
                    using (var pragma = cn.CreateCommand())
                    {
                        pragma.CommandText = "PRAGMA foreign_keys = ON;";
                        pragma.ExecuteNonQuery();
                    }
                    foreach (string sql in migrations)
                    {
                        using (var cmd = cn.CreateCommand())
                        {
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Migration error:\n\n" + ex.Message, "Database Migration", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
