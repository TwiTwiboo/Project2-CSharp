﻿using System.ComponentModel.DataAnnotations;
using TripMeOn.Models.PartnerProducts;
using TripMeOn.Models.Products;

namespace TripMeOn.Models.Order
{
    public class ItemService
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int AccomodationId { get; set; }
        public Accomodation Accomodation{ get; set; }
        public int TransportId { get; set; }
        public Transportation Transportation { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}