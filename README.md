# ETT-tabuSearch

## Tabu Search

Tabu Search keeps around a history of recently considered candidate solutions (known as the tabu list) and refuses to return to those candidate solutions until they’re sufficiently far in the past. Thus if we wander up a hill, we
have no choice but to wander back down the other side because we’re not permitted to stay at or return to the top of the hill.

Below is the pseudocode for Tabu Search:

```
1: l ← Desired maximum tabu list length
2: n ← number of tweaks desired to sample the gradient
3: S ← some initial candidate solution
4: Best ← S
5: L ← {} a tabu list of maximum length l                > Implemented as first in, first-out queue
6: Enqueue S into L
7: repeat
8:    if Length(L) > l then
9:        Remove oldest element from L
10:   R ← Tweak(Copy(S))
11:   for n − 1 times do
12:       W ← Tweak(Copy(S))
13:       if W ∈/ L and (Quality(W) > Quality(R) or R ∈ L) then
14:          R ← W
15:   if R ∈/ L then
16:      S ← R
17:      Enqueue R into L
18:   if Quality(S) > Quality(Best) then
19:      Best ← S
20: until Best is the ideal solution or we have run out of time
21: return Best
```
 
## Tests results

Each instance was ran 5 times for 3 minutes.

Instance | Min | Max | Avg
--- | --- | --- | --- 
D1-1-16 | 137 | 142 | 138.6
D1-1-17 | 115 | 120 | 117
D1-2-16 | 341 | 347 | 343.8
D1-2-17 | 352 | 355 | 354
D1-3-16 | 383 | 386 | 384.8
D1-3-17 | 329 | 332 | 330.2
D1-3-18 | 71 | 75 | 73
D2-1-18 | 58 | 62 | 60.4
D2-2-18 | 43 | 49 | 47.4
D2-3-18 | 27 | 28 | 27.5
D3-1-16 | 0 | 0 | 0
D3-1-17 | 0 | 0 | 0
D3-1-18 | 0 | 0 | 0
D3-2-16 | 0 | 0 | 0
D3-2-17 | 0 | 0 | 0 
D3-2-18 | 0 | 0 | 0
D3-3-16 | 0 | 0 | 0 
D3-3-17 | 0 | 0 | 0
D3-3-18 | 0 | 0 | 0
D4-1-17 | 101 | 105 | 103
D4-1-18 | 155 | 158 | 157.2
D4-2-17 | 167 | 171 | 169
D4-2-18 | 221 | 224 | 222.6
D4-3-17 | 449 | 458 | 453.8
D4-3-18 | 598 | 601 | 599.2
D5-1-17 | 49 | 53 | 50.8
D5-1-18 | 25 | 28 | 26.5
D5-2-17 | 40 | 45 | 43.7
D5-2-18 | 20 | 23 | 21.2
D5-3-18 | 0 | 0 | 0
D6-1-16 | 580 | 592 | 585.8
D6-1-17 | 572 | 575 | 572.2
D6-1-18 | 587 | 600 | 592.2
D6-2-16 | 772 | 795 | 784.4
D6-2-17 | 798 | 802 | 800.2
D6-2-18 | 499 | 501 | 500
D6-3-16 | 352 | 356 | 354.6
D6-3-17 | 402 | 411 | 406
D7-1-17 | 123 | 125 | 124
D7-2-17 | 127 | 129 | 128

