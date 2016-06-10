using UnityEngine;
using System.Collections;

public class Level{
    public Island reset_state;
    public int points_to_next_level;
    public string level_instructions;

    public Level(Island reset_state1, int points_to_next_level1, string level_instructions1) {
        reset_state = reset_state1;
        points_to_next_level = points_to_next_level1;
        level_instructions = level_instructions1;
    }
}
