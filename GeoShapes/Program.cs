using GeoShapes.src;

Catalog catalog = new Catalog();
catalog.Load(); // 👈 načte JSON při startu

UserInterface ui = new UserInterface(catalog);
ui.Run();