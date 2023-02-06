// See https://aka.ms/new-console-template for more information
string file = "data.txt";
Console.WriteLine("Hello, World!");
// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // TODO: create data file
    // create data file
     StreamWriter sw = new StreamWriter("data.txt");

     Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    Console.WriteLine(dataDate);
    // random number generator
    Random rnd = new Random();

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
            //sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        sw.WriteLine($"{dataDate:M/d/yy}|{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
        
    }
    sw.Close();
}
else if (resp == "2")
{
    
            
     StreamReader sr = new StreamReader(file);
         while (!sr.EndOfStream){
              string line = sr.ReadLine();
                 // convert string to array
             string[] data = line.Split('|');
             

                // display array data
               
             
                DateTime weekHeader = DateTime.Parse(data[0]);
                float tot = Int32.Parse(data[1]) + Int32.Parse(data[2]) + Int32.Parse(data[3]) + Int32.Parse(data[4]) + Int32.Parse(data[5]) + Int32.Parse(data[6]) + Int32.Parse(data[7]);
                float avg = (Int32.Parse(data[1]) + Int32.Parse(data[2]) + Int32.Parse(data[3]) + Int32.Parse(data[4]) + Int32.Parse(data[5]) + Int32.Parse(data[6]) + Int32.Parse(data[7])) / 7;
                
                
                

                Console.WriteLine($"Week of {weekHeader:MMMM}, {weekHeader:dd}, {weekHeader:yyyy}");
                Console.WriteLine(" {0,2} {1,2} {2,2} {3,2} {4,2} {5,2} {6,2} {7,3} {8,3}","Mo","Tu","We","Th","Fr","Sa","Su","Tot","Avg");
                Console.WriteLine(" {0,2:C2} {0,2:C2} {0,2:C2} {0,2:C2} {0,2:C2} {0,2:C2} {0,2:C2} {1,3:C2} {1,3:C2}","--","---");
                Console.WriteLine(" {0,2:C3} {1,2:C3} {2,2:C3} {3,2:C3} {4,2:C3} {5,2:C3} {6,2:C3} {7,3} {8,3}", data[1], data[2], data[3], data[4], data[5], data[6], data[7], tot, avg);
                Console.WriteLine(" ");
                
               
                
                    } 
             
            
         sr.Close();

}