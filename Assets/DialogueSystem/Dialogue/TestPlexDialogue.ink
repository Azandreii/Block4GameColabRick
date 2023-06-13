Hi there, I'm <color=\#00FF00>Plex</color> ! #speaker:Plex #portrait:plex_neutral #layout:left
-> main

=== main ===
Are you lost?
    + [Yes]
        -> chosen("Yes.")
    + [No]
        -> chosen("No")
    + [Maybe??]
        -> chosen("Maybe")
        
=== chosen (answer) ===
 <color=\#FF0000>{answer}</color>. #speaker:Noah #portrait:noah_neutral #layout:right
Ok, let me help you. #speaker:Plex #portrait:plex_neutral #layout:left
 -> END 