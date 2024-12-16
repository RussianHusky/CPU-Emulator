﻿using System.Net;

class Program
{
    static void Main(string[] args)
    {
        CPU cpu = new CPU(256);

        /*string[] program = new string[]
        {
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
            "Pop",
            "Pop",
            "End",
        };*/

        string[] program = new string[] // Finds max in data memory only, ignores the accumulator stack. First 2 commands are for testing
        {
            "Push 200",
            "Push 500",
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
            "Pop",
            "Pop",
            /*"Pop",    // Different debug
            "Push 150",
            "Store",
            "Push 0",   // [max]
            "Push Data",    // [ind, max]
            "Push Data",    // [ind, ind, max]
            "Max1:", // Compare
            "Load", // [int, ind, max]
            "Rol",  // [ind, max, int]
            "Rol",  // [max, int, ind]
            "Comp", // [max > int]
            "JumpZ NewMax1", // if false jump NewMax
            "Swap", // if true [int, max, ind]
            "Pop",  // [int -> max, ind]
            "Checked1:",
            "Swap", // [ind, max]
            "Push 1", // [1, ind, max]
            "Add",  // [ind += 1, max]
            "SP", // [SP, ind, max]
            "Comp", // SP > ind
            "JumpNZ Iterate1", // if true jump Iterate
            "Jump EndComp1",
            "Iterate1:",
            "Pop",  // [ind, max]
            "Dup",  // [ind, ind, max]
            "Load", // [int, ind, max]
            "Jump Max1", // jump to beginning
            "NewMax1:",
            "Pop",  // [max, ind]
            "Jump Checked1",
            "EndComp1:", // [ind, ind, max]
            "Pop",  // [ind, max]
            "Pop",*/  // [max]
            "End"
        };

        int[] data = new int[]
        {
            100,
            101,
            103,
            100,
            77
        };

        cpu.LoadProgram(program, data);

        cpu.Run();
    }
}
