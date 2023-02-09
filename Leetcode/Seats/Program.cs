using System.Numerics;

namespace Seats;
class Program
{
    static void Main(string[] args)
    {
        var show = new BookMyShow(3, 999999999);
        var x = show.Scatter(1000000000, 2);
        //BookMyShow bms = new BookMyShow(2, 5); // There are 2 rows with 5 seats each 
        //var x = bms.Gather(4, 0); // return [0, 0]
        //                          // The group books seats [0, 3] of row 0. 

        //var x2 = bms.Gather(2, 0); // return []
        //                           // There is only 1 seat left in row 0,
        //                           // so it is not possible to book 2 consecutive seats. 
        //var can1 = bms.Scatter(5, 1); // return True
        //                              // The group books seat 4 of row 0 and seats [0, 3] of row 1. 
        //var can2 = bms.Scatter(5, 1); // return False
        //                              // There is only one seat left in the hall.
    }
}

public class BookMyShow
{
    int maxRowNumber;
    int maxColNumber;
    int[] lastSoldSeat;
    int maxLastSeat;
    BigInteger availableSeats;

    public BookMyShow(int n, int m)
    {
        maxRowNumber = n;
        maxColNumber = m;
        maxLastSeat = maxColNumber - 1;
        lastSoldSeat = new int[maxRowNumber];
        availableSeats = (BigInteger)m * (BigInteger)n;
        for (var i = 0; i < maxRowNumber; i++)
        {
            lastSoldSeat[i] = -1;
        }
    }

    public int[] Gather(int k, int maxRow)
    {
        if (maxColNumber < k || availableSeats < k)
        {
            return Array.Empty<int>();
        }

        for (var i = 0; i <= maxRow; i++)
        {
            if (lastSoldSeat[i] + k < maxColNumber)
            {
                var firstSeat = lastSoldSeat[i];
                lastSoldSeat[i] += k;
                availableSeats -= k;
                return new[] { i, firstSeat + 1 };
            }
        }

        return Array.Empty<int>();
    }

    public bool Scatter(int k, int maxRow)
    {
        if (availableSeats < k)
        {
            return false;
        }

        var reservationSum = 0;
        bool canAllocate = false;

        for (var i = 0; i <= maxRow; i++)
        {
            reservationSum += maxLastSeat - lastSoldSeat[i];

            if (reservationSum >= k)
            {
                canAllocate = true;
                availableSeats -= k;
                break;
            }
        }

        if (!canAllocate)
        {
            return false;
        }

        var toReserve = k;

        for (var i = 0; i <= maxRow; i++)
        {
            var currentRowEmptySeats = maxLastSeat - lastSoldSeat[i];
            if (toReserve > currentRowEmptySeats)
            {
                lastSoldSeat[i] = maxLastSeat;
                toReserve -= currentRowEmptySeats;
            }
            else
            {
                lastSoldSeat[i] += toReserve;
                break;
            }
        }

        return true;
    }
}