using BoreholeData;
using BoreholeData.Entities;
using BoreholeData.Repositories;
using System.Runtime.InteropServices;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Borehole time!");

Borehole bh = new Borehole() { X = 1, Y = 2, Depth = 123.45M };

BoreholeContext boreholeContext = new BoreholeContext(null);
BoreholeRepository repo = new BoreholeRepository(boreholeContext);

Console.WriteLine("Adding Basic borehole...");
int bhID = repo.Add(bh);

CableBorehole cable = new CableBorehole() { X = 4, Y = 4, Depth = 234.12M, CableStrength = "Strong", CableType = BoreholeData.Enums.CableType.Steel};
DrillBorehole drill = new DrillBorehole() { X = 2, Y = 7, Depth = 223.27M, DrillStrength = "Medium", DrillType = BoreholeData.Enums.DrillType.TungstenCarbide };

Console.WriteLine("Adding Subtype borehole...");
int cabID = repo.Add(cable);
int drillID = repo.Add(drill);

Console.WriteLine($"Boreholes Added with IDS {bhID} {cabID} {drillID}, press any key to continue...");
Console.ReadKey(false);

Console.WriteLine("Editing the Cable BH...");

cable.Depth = 75.233M;
cable.CableType = BoreholeData.Enums.CableType.Dynema;
cable.CableStrength = "Weak";

repo.Edit(cable);

Console.WriteLine("Edited, press any key to continue...");
Console.ReadKey(false);

Console.WriteLine("Deleting the Drill BH...");

repo.Delete(drillID);

Console.WriteLine("Deleted, press any key to continue...");
Console.ReadKey(false);

Console.WriteLine("Adding more BH to make queries interesting");

repo.Add(new DrillBorehole() { X = 0, Y = 0, Depth = 154.27M, DrillStrength = "Medium", DrillType = BoreholeData.Enums.DrillType.TungstenCarbide });
repo.Add(new DrillBorehole() { X = 5, Y = 2, Depth = 634.27M, DrillStrength = "Weak", DrillType = BoreholeData.Enums.DrillType.Diamond });
repo.Add(new DrillBorehole() { X = 2, Y = 7, Depth = 235.27M, DrillStrength = "Strong", DrillType = BoreholeData.Enums.DrillType.Auger });

var bhs = repo.GetByArea(2, 2, 6, 6).Select(bh => bh.ID);
var bhById = repo.GetById(1);

Console.WriteLine(bhById);
Console.WriteLine($"Number of BH found between (2,2) and (6,6): {bhs.Count()}");
Console.WriteLine("Done, press any key to continue...");
Console.ReadKey(false);


