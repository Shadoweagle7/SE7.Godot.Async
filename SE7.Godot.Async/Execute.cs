using Godot;

namespace SE7.Godot.Async
{
    public class Execute
    {
        // TOOO: Godot does have GodotSynchronizationContext. How to use it such that async/await can be performed?
        // The main issue is that async/await cannot be bubbled up into Godot's engine. Perhaps we need to write code
        // that interfaces with Godot's engine to do so?

        /*
         * All of these were found in Godot's Source Code on Github.
         
        C++: OS Windows derived class ::run()
              -> while (!Main::iteration()) {
                     Keep running program. Main::iteration() returns true if program is finished
                 }
              ->
                    for (int i = 0; i < ...; i++) {
                        collection of programming languages -> get script ------> frame()
                    }
         ------> frame()
              -> ScriptManagerBridge_FrameCallback delegate C++ Side
              -> ScriptManagerBridge_FrameCallback delegate C#  Side
              -> Activate()
              -> GodotSynchronizationContext.ExecutePendingContinuations()
                 -> BlockingCollection of implicitly-typed ValueTuple<SendOrPostCallback, object?>
                 -> while (try take from BlockingCollection with out param if succeeded)
                    {
                        out param is implicitly-typed ValueTuple<SendOrPostCallback, object?>.
                        
                        param.Item1(param.Item2);
                    }


            TODO: Perhaps switch synchronization context to custom synchronization context that can
                  do async whenever needed?

                  But where to bubble up to?
         */

        public Task Async(Action action)
        {
            global::Godot.GodotSynchronizationContext godotSynchronizationContext;
            global::Godot.GodotTaskScheduler godotTaskScheduler;
            global::Godot.GodotThread godotThread; // TODO: Might not be able to use this due to how tightly it is bound to Godot's API. Check anyways - might be useful.
        }
    }
}
