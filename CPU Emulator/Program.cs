using System.Net;

class Program
{
    static void Main(string[] args)
    {
        CPU cpu = new CPU(64);

        /*string[] program = new string[]
        {
            "Push 8",
            "Push 5",
            "Loop:",
            "Push 1",
            "Add",
            "Comp",
            "JumpZ Loop",
            "End"
        };*/

        string[] program = new string[] // Finds max in data memory only, ignores the accumulator stack. First 2 commands are for testing
        {   "Push 200",
            "Push 400",
            "Push 0",   // [max]
            "Push Data",    // [ind, max]
            "Push Data",    // [ind, ind, max]
            "Max:", // Compare
            "Load", // [int, ind, max]
            "Rol",  // [ind, max, int]
            "Rol",  // [max, int, ind]
            "Comp", // [max > int]
            "JumpZ NewMax", // if false jump NewMax
            "Swap", // if true [int, max, ind]
            "Pop",  // [int -> max, ind]
            "Checked:",
            "Swap", // [ind, max]
            "Push 1", // [1, ind, max]
            "Add",  // [ind += 1, max]
            "SP", // [SP, ind, max]
            "Comp", // SP > ind
            "JumpNZ Iterate", // if true jump Iterate
            "Jump EndComp",
            "Iterate:",
            "Pop",  // [ind, max]
            "Dup",  // [ind, ind, max]
            "Load", // [int, ind, max]
            "Jump Max", // jump to beginning
            "NewMax:",
            "Pop",  // [max, ind]
            "Jump Checked",
            "EndComp:", // [ind, ind, max]
            "Pop",  // [ind, max]
            "Pop",  // [max]
            "End"
        };

        int[] data = new int[]
        {
            101,
            102,
            103,
            105,
            77
        };

        cpu.LoadProgram(program, data);

        cpu.Run();
    }
}
