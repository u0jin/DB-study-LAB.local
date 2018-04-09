using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace _DB연동_0327_
{
    class Con_Database
    {
        //static String constring1 = "Server=localhost;Database=ujindb;Uid=root;Pwd=tryit5826;SslMode=none;Charset=utf8;";
         static String constring1 = "Server=117.17.142.111;Database=cosmosDB;Uid=ujin;Pwd=1234;SslMode=none;Charset=utf8";
        MySqlConnection conn = new MySqlConnection(constring1); //데이터베이스와 연결을 담당하는 객체 생성
        Form1 frm1;
        
        MySqlDataAdapter adapter;


        public string sConnstring = "";

        public Con_Database(Form1 _frm1)
        {
            frm1 = _frm1;

        }

        public void ConnectDB()
        {
            //GridVeiw1에 보여줌

            try
            {
                conn.Open();

                string sql = "SELECT * FROM data ORDER BY id";

                adapter = new MySqlDataAdapter(sql, conn);


                DataSet ds = new DataSet();

                adapter.Fill(ds, "data");
                frm1.dataGridView1.DataSource = ds.Tables[0];

                conn.Close();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                conn.Close();
            }

        }

        public void CloseDB()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }


        public DataTable GetDBTable(string sql)
        {

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            return dt;

        }


        public void deleteFunc(object rc)
        { //db delete 함수 설정
            conn.Open();
            
            string sql = "delete from data where id = '"+rc.ToString()+"' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            
            cmd.ExecuteNonQuery();
            conn.Close();

            ConnectDB();

        }
        public void addFunc()
        { //db delete 함수 설정
            //insert-> 삽입 과 추가

            conn.Open();
            
            string sql = "insert into data values < 'id','name','phone_number','e_mail','address'> ";
            

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.ExecuteNonQuery();
            conn.Close();

            ConnectDB();

        }




    }
}
