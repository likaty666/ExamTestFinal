using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace CinemaUI.Hubs
{
    public class PlaneHub : Hub
    {
       
        static string userId;

        private static List<PlaneSeatsArrangement> allSeats = new List<PlaneSeatsArrangement>();

        public void CreateUser()
        {
           userId= this.Context.ConnectionId;
           
            Clients.All.createUser(userId);
        }

        public void PopulateSeatData()
        {
            var returnData = Newtonsoft.Json.JsonConvert.SerializeObject(allSeats);
            Clients.All.populateSeatData(returnData);
        }

        public void SelectSeat(string userId, int seatNumber,int sess_id,string cookieId)
        {
            //create document model
            var planeSeatsArrangement = new PlaneSeatsArrangement() { SeatNumber = seatNumber, UserId = userId, SessId= sess_id, AspId = cookieId };
            allSeats.Add(planeSeatsArrangement);
            var returnData = Newtonsoft.Json.JsonConvert.SerializeObject(planeSeatsArrangement);
            Clients.All.selectSeat(returnData);
        }
        public void DeleteSeat(string userId, int seatNumber, int sess_id, string cookieId)
        {
            //create document model
            var planeSeatsArrangement = new PlaneSeatsArrangement() { SeatNumber = seatNumber, UserId = userId, SessId = sess_id, AspId = cookieId };
            allSeats.Add(planeSeatsArrangement);
            var returnData = Newtonsoft.Json.JsonConvert.SerializeObject(planeSeatsArrangement);
            Clients.All.deleteSeat(returnData);
        }
    }

    public class PlaneSeatsArrangement
    {
        [JsonProperty(PropertyName = "userid")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "seatnumber")]
        public int SeatNumber { get; set; }

        [JsonProperty(PropertyName = "sessid")]
        public int SessId { get; set; }

        [JsonProperty(PropertyName = "aspid")]
        public string AspId { get; set; }

    }
}