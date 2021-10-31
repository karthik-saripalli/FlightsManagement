using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightsBAL;
using System.Data.SqlClient;
using System.Data;
namespace FlightsDAL
{
    public class DALFlights
    {
        public DataTable showDetails()
        {
            SqlConnection con = new SqlConnection("server=LAPTOP-362TBH8P\\SQLEXPRESS;Integrated security=True;database=FlightDB");
            SqlDataAdapter da = new SqlDataAdapter("select * from Flights", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Flights");
            return ds.Tables["Flights"];
        }

        public BALFlights findFlight(int id)
        {
            SqlConnection con = new SqlConnection("server=LAPTOP-362TBH8P\\SQLEXPRESS;Integrated security=True;database=FlightDB");
            SqlDataAdapter da = new SqlDataAdapter("select * from Flights", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "Flights");
            DataRow r = ds.Tables["Flights"].Rows.Find(id);
            BALFlights b = new BALFlights();
            b.FlightId = id;
            b.FlightName = r["FlightName"].ToString();
            b.FlightArrival = Convert.ToDateTime(r["FlightArrival"]);
            b.FlightDeparture = Convert.ToDateTime(r["FlightDeparture"]);
            b.PassengersCount = Convert.ToInt32(r["PassengerCount"]);
            b.CaptainID = Convert.ToInt32(r["CaptainId"]);

            return b;
        }
        
        public void insertFlights(BALFlights b)
        {
            SqlConnection con = new SqlConnection("server=LAPTOP-362TBH8P\\SQLEXPRESS;Integrated security=True;database=FlightDB");
            SqlDataAdapter da = new SqlDataAdapter("select * from Flights", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "Flights");
            DataRow r = ds.Tables["Flights"].NewRow();
            r["FlightName"] = b.FlightName;
            r["FlightArrival"] = b.FlightArrival;
            r["FlightDeparture"] = b.FlightDeparture;
            r["PassengerCount"] = b.PassengersCount;
            r["Captainid"] = b.CaptainID;
            ds.Tables["Flights"].Rows.Add(r);
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            da.Update(ds.Tables["Flights"]);
        }
        public void UpdateFlight(int id,BALFlights b)
        {
            SqlConnection con = new SqlConnection("server=LAPTOP-362TBH8P\\SQLEXPRESS;Integrated security=True;database=FlightDB");
            SqlDataAdapter da = new SqlDataAdapter("select * from Flights", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "Flights");
            DataRow r = ds.Tables["Flights"].Rows.Find(id);
            r["FlightName"] = b.FlightName;
            r["FlightArrival"] = b.FlightArrival;
            r["FlightDeparture"] = b.FlightDeparture;
            r["PassengerCount"] = b.PassengersCount;
            r["Captainid"] = b.CaptainID;
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            da.Update(ds.Tables["Flights"]);
        }
        public void DeleteFlight(int id)
        {
            SqlConnection con = new SqlConnection("server=LAPTOP-362TBH8P\\SQLEXPRESS;Integrated security=True;database=FlightDB");
            SqlDataAdapter da = new SqlDataAdapter("select * from Flights", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "Flights");
            DataRow r = ds.Tables["Flights"].Rows.Find(id);
            r.Delete();
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            da.Update(ds.Tables["Flights"]);
        }
    }
}
