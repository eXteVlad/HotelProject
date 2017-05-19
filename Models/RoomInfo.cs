using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Hotel
{
    public class RoomInfo
    {
        [Key]
        public int id { get; set; }
        public int idClient { get; set; }
        public int numRoom { get; set; }
        public int placeRoom { get; set; }
        public int priceRoom { get; set; }
        public string catRoom { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dateinRoom { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dateoutRoom { get; set; }
    }
}