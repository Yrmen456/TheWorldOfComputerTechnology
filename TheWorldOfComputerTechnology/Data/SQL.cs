using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfComputerTechnology.Data
{
    class SQL
    {
        public static string Conect()
        {
            string startupPath = Environment.CurrentDirectory;
            //ВСТРОЕННАЯ
            //return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={startupPath}\Database\GaсhiMishaShop.mdf;Integrated Security=True;Connect Timeout=30";
            //ДОМ
            return @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TheWorldOfComputerTechnology;Integrated Security=True";
            //ТЕХ
            //return @"Data Source=PC311-7;Initial Catalog=TheWorldOfComputerTechnology;Integrated Security=True";

        }


        public static DataSet Table(string query)
        {
            DataSet Table = new DataSet();

            SqlConnection con = new SqlConnection(SQL.Conect());
            try
            {
                con.Open();
            }
            catch (Exception)
            {

                return Table;
            }
            try
            {
                SqlDataAdapter a = new SqlDataAdapter(query, con);
                a.Fill(Table);
                return Table;
            }
            catch (Exception)
            {

                return Table;
            }

        }

        public static bool Query(string query)
        {
            DataSet Table = new DataSet();

            SqlConnection con = new SqlConnection(SQL.Conect());
            try
            {
                con.Open();
            }
            catch (Exception)
            {

                return false;
            }
            try
            {
                SqlDataAdapter a = new SqlDataAdapter(query, con);
                a.Fill(Table);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
