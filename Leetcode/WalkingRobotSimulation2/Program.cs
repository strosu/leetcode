namespace WalkingRobotSimulation2;
class Program
{
    static void Main(string[] args)
    {
        var r = new Robot(6, 3);
        r.Step(2);
        r.Step(2);
        var p1 = r.GetPos();
        var d1 = r.GetDir();
        r.Step(2);
        r.Step(1);
        r.Step(4);
        var p2 = r.GetPos();
        var d2 = r.GetDir();

        //var robot = new Robot(20, 14);

        //robot.Step(32);
        //robot.Step(18);
        //robot.Step(18);
        //var pos = robot.GetPos();

        Console.ReadLine();
    }

    public class Robot
    {
        private byte currentCellId;
        private bool leftFirstCell = false;

        private byte _width;
        private byte _height;
        private short modulo;

        public Robot(int width, int height)
        {
            _width = (byte)width;
            _height = (byte)height;
            modulo = (short)(_height * 2 + _width * 2 - 4);
        }

        public void Step(int num)
        {
            if (!leftFirstCell)
            {
                leftFirstCell = true;
            }

            int newValue = (currentCellId + num) % modulo;
            currentCellId = (byte)newValue;
        }

        public int[] GetPos()
        {
            var result = GetCurrentCell();

            return new int[] { result.x, result.y };
        }

        public string GetDir()
        {
            return GetCurrentCell().direction;
        }

        private (string direction, byte x, byte y) GetCurrentCell()
        {
            if (currentCellId == 0)
            {
                return (leftFirstCell ? "South" : "East", 0, 0);
            }

            string? direction = "";
            byte column = 0; ;
            byte row = 0;

            if (currentCellId < _width)
            {
                direction = "East";
                column = currentCellId;
                row = 0;
            }

            if (currentCellId >= _width && currentCellId < _width + _height)
            {
                row = (byte)(currentCellId - _width + 1);
                column = (byte)(_width - 1);
                direction = "North";
            }

            if (currentCellId >= _width + _height && currentCellId < 2 * _width + _height)
            {
                column = (byte)(_width - 1 + (_height - 2) + (_width - 1) - currentCellId + 1);
                row = (byte)(_height - 1);
                direction = "West";
            }

            if (currentCellId >= 2 * _width + _height)
            {
                row = (byte)(modulo - currentCellId);
                column = 0;
                direction = "South";
            }

            return (direction, column, row);
        }
    }
}

