using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWcfSevice
{
    public class Logger
    {
        public static Logger _instance;

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Logger();

                return _instance;
            }
        }

        public void InputLogDetails(string Request, string Response, string Comment)
        {
            var cluster = Cluster.Builder()
                                   .AddContactPoints("127.0.0.1")
                                   .Build();

            var session = cluster.Connect("hotels");

            string query = "Insert into  LogDetails  (LogId, Request, Response, Comment, Time) values (uuid(),'" + Request + "', '" + Response + "', '" + Comment + "', dateof(now()))";

            var res = session.Execute(query);

        }
    }
}