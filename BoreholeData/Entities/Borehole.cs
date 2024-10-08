﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BoreholeData.Entities
{

    [JsonDerivedType(typeof(CableBorehole), typeDiscriminator: "Cable")]
    [JsonDerivedType(typeof(DrillBorehole), typeDiscriminator: "Drill")]
    public class Borehole
    {
        public int ID { get; set; }
        public decimal Depth { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"Borehole with ID: {ID}, at ({X},{Y} with Depth {Depth}";
        }

    }
}
