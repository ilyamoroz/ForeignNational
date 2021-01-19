using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ForeignNational
{
    class DB
    {
        MySqlConnection sqlconnection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=citizens");
        public void openConnection()
        {
            if (sqlconnection.State == System.Data.ConnectionState.Closed)
            {
                sqlconnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlconnection.State == System.Data.ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
        public MySqlConnection GetConnection() => sqlconnection;
        public bool AddNewCitizen(string name, string secondName, string fatherName, string country, string birthDate, string martialStatus, string city, string currentAddress, string termOfStay)
        {
            MySqlCommand commandForAdd = new MySqlCommand("INSERT INTO `citizen`(`Name`, `Surname`, `FatherName`, `Country`, `BirthDate`, `MartialStatus`, `City`,`CurrentAddress`, `TermOfStay`) " +
                    "VALUES (@name,@secondName,@fatherName,@country,@birthDate,@martialStatus,@city,@currentAddress, @termOfStay)", GetConnection());
            commandForAdd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            commandForAdd.Parameters.Add("@secondName", MySqlDbType.VarChar).Value = secondName;
            commandForAdd.Parameters.Add("@fatherName", MySqlDbType.VarChar).Value = fatherName;
            commandForAdd.Parameters.Add("@country", MySqlDbType.VarChar).Value = country;
            commandForAdd.Parameters.Add("@birthDate", MySqlDbType.VarChar).Value = birthDate;
            commandForAdd.Parameters.Add("@martialStatus", MySqlDbType.VarChar).Value = martialStatus;
            commandForAdd.Parameters.Add("@city", MySqlDbType.VarChar).Value = city;
            commandForAdd.Parameters.Add("@currentAddress", MySqlDbType.VarChar).Value = currentAddress;
            commandForAdd.Parameters.Add("@termOfStay", MySqlDbType.VarChar).Value = termOfStay;

            openConnection();
            commandForAdd.ExecuteNonQuery();
            closeConnection();
            return true;
        }
        public DataTable GetPeople(string table)
        {
            DataTable dt = new DataTable();
            MySqlCommand GetCommand = new MySqlCommand("SELECT * FROM `" + table + "`", GetConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(GetCommand);
            adapter.Fill(dt);
            return dt;
        }

        public void DeleteCitizen(int id, string table)
        {
            MySqlCommand DeleteCommand = new MySqlCommand("DELETE FROM `" + table + "` WHERE `ID` = @ID", GetConnection());
            DeleteCommand.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;

            openConnection();
            DeleteCommand.ExecuteNonQuery();
            closeConnection();

        }
        public void SendTo(int id, string table)
        {
            MySqlCommand GetByIDCommand = new MySqlCommand("SELECT * FROM `citizen` WHERE `ID` =  @id", GetConnection());
            GetByIDCommand.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            openConnection();
            GetByIDCommand.ExecuteNonQuery();
            closeConnection();



            openConnection();
            MySqlDataReader reader;
            reader = GetByIDCommand.ExecuteReader();


            MySqlCommand commandForAdd = new MySqlCommand(@"INSERT INTO `" + table + "`(`Name`, `Surname`, `FatherName`, `Country`, `BirthDate`, `MartialStatus`, `City`, `CurrentAddress`, `TermOfStay`) " +
                    "VALUES (@name,@secondName,@fatherName,@country,@birthDate,@martialStatus,@city, @currentAddress, @termOfStay)", GetConnection());

            while (reader.Read())
            { 
                commandForAdd.Parameters.Add("@name", MySqlDbType.VarChar).Value = reader[1];
                commandForAdd.Parameters.Add("@secondName", MySqlDbType.VarChar).Value = reader[2];
                commandForAdd.Parameters.Add("@fatherName", MySqlDbType.VarChar).Value = reader[3];
                commandForAdd.Parameters.Add("@country", MySqlDbType.VarChar).Value = reader[4];
                commandForAdd.Parameters.Add("@city", MySqlDbType.VarChar).Value = reader[5];
                commandForAdd.Parameters.Add("@currentAddress", MySqlDbType.VarChar).Value = reader[6];
                commandForAdd.Parameters.Add("@birthDate", MySqlDbType.VarChar).Value = reader[7];
                commandForAdd.Parameters.Add("@martialStatus", MySqlDbType.VarChar).Value = reader[8];
                commandForAdd.Parameters.Add("@termOfStay", MySqlDbType.VarChar).Value = reader[9];
            }
            closeConnection();
            openConnection();
            commandForAdd.ExecuteNonQuery();
            closeConnection();
            DeleteCitizen(id, "citizen");
        }
    }
}

