using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlightsBAL;
using FlightsDAL;
using System.Collections;
using System.Data;
using FlightManagement.Models;

namespace FlightManagement.Controllers
{
    public class FlightsController : ApiController
    {
        // GET api/<controller>
        public static List<BALFlights> flist = new List<BALFlights>();
        public List<BALFlights> GetFlightsList()
        {
            DALFlights d = new DALFlights();
            DataTable t = new DataTable();
            t = d.showDetails();
            for(int i=0;i<t.Rows.Count;i++)
            {
                BALFlights f = new BALFlights();
                f.FlightId = Convert.ToInt32(t.Rows[i][0]);
                f.FlightName= t.Rows[i][1].ToString();
                f.FlightArrival = Convert.ToDateTime(t.Rows[i][2]);
                f.FlightDeparture= Convert.ToDateTime(t.Rows[i][3]);
                f.PassengersCount = Convert.ToInt32(t.Rows[i][4]);
                f.CaptainID = Convert.ToInt32(t.Rows[i][5]);
                flist.Add(f);
            }
            return flist;
        }

        // GET api/<controller>/5
        public Flights Get(int id)
        {
            DALFlights d = new DALFlights();
            BALFlights b = new BALFlights();
            b = d.findFlight(id);
            Flights f = new Flights();
            f.FlightId = b.FlightId;
            f.FlightName = b.FlightName;
            f.FlightArrival = b.FlightArrival;
            f.FlightDeparture = b.FlightDeparture;
            f.PassengersCount = b.PassengersCount;
            f.CaptainID = b.CaptainID;
            return f;
        }

        // POST api/<controller>
        public void Post([FromBody] BALFlights value)
        {
            DALFlights d = new DALFlights();
            BALFlights b = new BALFlights();
            b.FlightName = value.FlightName;
            b.FlightArrival = value.FlightArrival;
            b.FlightDeparture = value.FlightDeparture;
            b.PassengersCount = value.PassengersCount;
            b.CaptainID = value.CaptainID;
            d.insertFlights(b);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] BALFlights value)
        {
            DALFlights d = new DALFlights();
            d.UpdateFlight(id, value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            DALFlights d = new DALFlights();
            d.DeleteFlight(id);
        }
    }
}