using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class BetaDB : MonoBehaviour
{
    private string dbName = "URI=file:Achievement.db";

    void Start()
    {
        CreateDB();

        //For later use per level clear // Reference //
        //AddAchievement("Baby Steps", 1);
        //DisplayAchievements();
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS achievementname (Name VARCHAR(20), Num INT);";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void AddAchievement(string achName, int achNum)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO achievementname (Name, Num) VALUES ('" + achName + "', '" + achNum + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void DisplayAchievements()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM achievementname;";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Name: " + reader["Name"] + "\tNum: " + reader["Num"]);
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }
}
