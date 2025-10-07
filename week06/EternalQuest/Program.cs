using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        EXCEEDING REQUIREMENTS:
        
        I've added several features to enhance the gamification experience:
        
        1. LEVEL SYSTEM: Users level up every 1000 points. When they level up, 
           they get a celebratory message that encourages them to continue.
        
        2. NEGATIVE GOALS: I created a new goal type called "NegativeGoal" where 
           users lose points for bad habits they're trying to break. This helps 
           track both positive and negative behaviors.
        
        3. GOAL STATISTICS: The program now tracks and displays:
           - Total goals completed
           - Completion percentage
           - Current level based on points
        
        4. ENHANCED FEEDBACK: More engaging messages and visual indicators 
           when completing goals and leveling up.
        
        5. BADGE SYSTEM (conceptual): The level system acts as a simple badge 
           system where reaching certain milestones is acknowledged.
        */

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}