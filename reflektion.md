# Reflektion — Musiklistappen

**Namn:** [Yuk Ting Ku ]
**Datum:** [2026-10-28]

---

## Vad var svårast?

Det svåraste var att använda den befintliga databasen i mitt C#-program. Det var också en utmaning att skapa olika funktioner, till exempel att visa alla låtar, söka efter en låt, lägga till nya låtar och ta bort låtar. Funktionerna använder olika SQL-kommandon och C#-kod, vilket kändes annorlunda jämfört med att arbeta med databasen i DB Browser. 

---

## Vad lärde du dig?

Jag lärde mig mycket, särskilt hur man använder en befintlig SQLite-databas i ett C#-program. Jag lärde mig också hur man skapar funktioner som låter användaren söka efter information, visa låtar, lägga till nya låtar och ta bort låtar från databasen.
---

## Hur använde du ADO.NET i praktiken — vad kändes naturligt och vad var förvirrande?

Jag använde ADO.NET för att ansluta mitt C#-program till SQLite-databasen och köra SQL-kommandon. Att skriva SQL kändes ganska naturligt eftersom jag hade arbetat med SQL tidigare. Det som var mer förvirrande var hur man skriver C#-kod för att öppna en anslutning, skapa ett kommando, skicka in parametrar och läsa resultatet från databasen. Jag lärde mig hur dessa steg fungerar tillsammans för att skapa programmets olika funktioner.

---

## Varför ska man använda parameteriserade queries?

Vad kan hända om man klistrar ihop SQL med strängar i stället? (Tänk på Bobby Tables.)

[Skriv här]

---

## Om du hade mer tid — vad hade du lagt till eller gjort annorlunda?

[Skriv här]

---

## (VG) Varför delade du upp koden som du gjorde?

Resonera kring ditt designval: varför ligger databaskoden i `DbHandler` och inte i `Program.cs`? Vad hade blivit svårare om allt låg i samma fil?

[Skriv här]
