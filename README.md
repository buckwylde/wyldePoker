# wyldePoker solution

## wyldePoker project
Houses my partial C# port/refactor of HenryRLee/PokerHandEvaluator.
Only ported over evaluate_5, _6 and _7, the hash tables and functions
required for those evaluations. Added C# classes for Deck, Card and
Hand objects, should be able to simulate any poker game with just
those three objects.

## wyldePokerTest
Currently instantiates Deck and Hand objects, uses those to simulate
a hand of Texas Hold'Em. Output is like that of a console app, just
to a textbox. Keeps track of total hands evaluated and hand count for
each rank to compute %ages for benchmarking. Prints out table cards
and hole cards for each player, marks winner/split as well.

## wyldeLOGIC project
budding collection of generic utility functionality, currently houses
a proper RNG class, and a WIP app settings class.
