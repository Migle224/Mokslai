/*Migle Pucetaite, PS4, 3gr., 1310521, 2ud.: 2D*/
/*"A jaunesnis negu to paties kurso studentas B";*/
/*jaunesnisKursiokas(vaiva, egle).*/
/*jaunesnisKursiokas(toma, egle).*/

studentas(andrius, 3).
studentas(audrius, 2 ).
studentas(bronius, 1).
studentas(dalius, 3 ).
studentas(egle, 3).
studentas(greta, 2 ).
studentas(haroldas, 1).
studentas(igoris, 1).
studentas(jonas, 2).
studentas(klaudas, 1).
studentas(lina, 3).
studentas(migle, 1).
studentas(nora, 3).
studentas(orestas, 2).
studentas(pertas, 4).
studentas(rasa, 4).
studentas(simas, 1).
studentas(toma, 4).
studentas(ugne, 2).
studentas(vaiva, 3).
studentas(zilvinas, 4).
yraVyresnis(andrius, audrius).
yraVyresnis(audrius, bronius).
yraVyresnis(bronius, dalius).
yraVyresnis(dalius, egle).
yraVyresnis(egle, greta).
yraVyresnis(greta, haroldas).
yraVyresnis(haroldas, igoris).
yraVyresnis(igoris, jonas).
yraVyresnis(jonas, klaudas).
yraVyresnis(klaudas, lina).
yraVyresnis(lina, migle).
yraVyresnis(migle, nora).
yraVyresnis(nora, orestas).
yraVyresnis(orestas, petras).
yraVyresnis(petras, rasa).
yraVyresnis(rasa, simas).
yraVyresnis(simas, toma).
yraVyresnis(toma, ugne).
yraVyresnis(ugne, vaiva).
yraVyresnis(vaiva, zilvinas).

jaunesnisKursiokas(Jaunesnis, Vyresnis):-studentas(Jaunesnis, KursasJ),
	                                 studentas(Vyresnis, KursasV),
					 KursasJ =:= KursasV,
					 yraJaunesnis(Jaunesnis, Vyresnis).

yraJaunesnis(Tarpinis, Vyresnis):- yraVyresnis(Vyresnis, Tarpinis);
                                   yraVyresnis(X, Tarpinis), yraJaunesnis(X, Vyresnis).




