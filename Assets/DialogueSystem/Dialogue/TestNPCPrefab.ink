-> main

=== main ===
test npc 2 dialogue
    + [Yes]
        -> chosen("Yes")
    + [No]
        -> chosen("No")
    + [Maybe??]
        -> chosen("Maybe??")
        
=== chosen (answer) ===
ur answer is: {answer}.
 -> END