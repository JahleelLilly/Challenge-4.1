using System;

namespace ElectricityBillCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input: Customer details
            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Units Consumed: ");
            int unitsConsumed = int.Parse(Console.ReadLine());

            // Constants for charge rates
            const double rateUpTo199 = 1.20;
            const double rate200To399 = 1.50;
            const double rate400To599 = 1.80;
            const double rate600AndAbove = 2.00;

            // Calculate charges
            double totalCharges = 0.0;

            if (unitsConsumed <= 199)
            {
                totalCharges = unitsConsumed * rateUpTo199;
            }
            else if (unitsConsumed >= 200 && unitsConsumed < 400)
            {
                totalCharges = unitsConsumed * rate200To399;
            }
            else if (unitsConsumed >= 400 && unitsConsumed < 600)
            {
                totalCharges = unitsConsumed * rate400To599;
                // Apply surcharge if bill exceeds $400
                if (totalCharges > 400)
                {
                    double surcharge = totalCharges * 0.15;
                    totalCharges += surcharge;
                }
            }
            else
            {
                totalCharges = unitsConsumed * rate600AndAbove;
                // Apply surcharge if bill exceeds $400
                if (totalCharges > 400)
                {
                    double surcharge = totalCharges * 0.15;
                    totalCharges += surcharge;
                }
            }

            // Display results
            Console.WriteLine($"Customer IDNO: {customerId}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Units Consumed: {unitsConsumed}");
            Console.WriteLine($"Amount Charges @ $2.00 per unit: {totalCharges:F2}");
            Console.WriteLine($"Surcharge Amount: {(totalCharges - unitsConsumed * rate600AndAbove):F2}");
            Console.WriteLine($"Net Amount Paid By the Customer: {totalCharges:F2}");
        }
    }
}
