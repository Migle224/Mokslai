f(1, 1).
f(N, F):- N1 is N-1, f(N1, F1), F is N*F1.

dalinti(Dalinys, Daliklis, 1).
dalinti(Dalinys, Daliklis, Dalmuo):- DalinysNaujas is Dalinys-Daliklis, dalinti(DalinysNaujas, Daliklis, DalmuoNaujas), Dalmuo is DalmuoNaujas+1.