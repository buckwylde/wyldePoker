# wyldePoker
Just a warmup project, piddlin' with poker hands.

## Probability of making a specific hand (7 out of 52)

From https://www.pokerstrategy.com/strategy/various-poker/texas-holdem-probabilities/
Hand		    # of poss	% hit		    Odds
Royal Flush	4324		  0.003232062	30939:1		*at the time my code doesn't differentiate between straight flush and royal flush
Str Flush	  37260		  0.027850748	3589.57:1	*so I add these two percentages together for comparisons below
Quads		    224848		0.168067227	594:1
Full House	3473184		2.596102271	37.52:1
Flush		    4047644		3.025494123	32.05:1
Straight	  6180020		4.619382087	20.65:1
Trips		    6461620		4.829869755	19.7:1
Two pair	  31433400	23.49553641	3.26:1
Pair		    58627800	43.82254574	1.28:1
High card	  23294460	17.41191958	4.74:1

Sample hands dealt by WyldePoker random generator and shuffle algorithm
all hands dealt are added to totals, not just winning hand:

Expected	holdem 5 players 20K 	holdem 10 players 15K 	holdem 10 players 100K iterations
00.03%		   27 (00.02%) 			   45 (00.03%)			   303 (00.03%) - Straight Flush
00.16%		  162 (00.16%) 			  229 (00.15%)			  1651 (00.16%) - Quads
02.59%		 2675 (02.67%) 			 4015 (02.67%)			 26176 (02.61%) - Full House
03.02%		 3034 (03.03%) 			 4481 (02.98%)			 30126 (03.01%) - Flush
04.61%		 4651 (04.65%) 			 6945 (04.63%)			 46001 (04.60%) - Straight
04.82%		 4985 (04.98%) 			 7070 (04.71%)			 48366 (04.83%) - Trips
23.49%		23633 (23.63%) 			35669 (23.77%)			236022 (23.60%) - Two Pair
43.82%		43724 (43.72%) 			65459 (43.63%)			437671 (43.76%) - Pair
17.41%		17114 (17.11%) 			26087 (17.39%)			173684 (17.36%) - High Car%d
			    100005 - Total      150000 - Total      1000000 - Total Hands
