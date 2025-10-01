using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing", "This activity will help you relax by walking you through slow breathing. Clear your mind and focus on your breathing.") {}

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();

        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.Write("Breathe in... ");
            Countdown(3);
            elapsed += 3;

            if (elapsed >= duration) break;

            Console.Write("Breathe out... ");
            Countdown(3);
            elapsed += 3;
        }

        DisplayEndingMessage();
    }
}
