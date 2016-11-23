/*1.6 2.7 3.5 4.1*/
/*1.6  tr_suma(Sar,Sum): duotajame saraše Sar galima rasti tris iš eiles einancius skaicius, kuriu suma lygi Sum.*/
/*trSuma([1,5,7,8,9,7,5], 24).*/
/*--Pirma---------*/
sarasas([Pradzia|Likutis], Pradzia, Likutis).
trSuma(Sarasas, Suma):-
	          sarasas(Sarasas, PirmasDemuo, LikutisPirmas),
	          sarasas(LikutisPirmas, AntrasDemuo, LikutisAntras),
		  sarasas(LikutisAntras, TreciasDemuo, _),
		  PirmasDemuo + AntrasDemuo + TreciasDemuo =:= Suma;
		  sarasas(Sarasas, _, LikutisPirmas),
		  trSuma(LikutisPirmas, Suma).
/*-------Antra------------*/
/*Skaicius Skaic atitinka duota dešimtainiu skaitmenu saraša Sar.
 des_skaic([1,9,8,5],X).*/

sarasas_2_skaicius([SarasoPradzia|SarasoPabaiga], SkaiciusN, Pradzia):-
	sarasas_2_skaicius(SarasoPabaiga, Skaicius, Pradzia),
	SkaiciusN is Skaicius * 10 + SarasoPradzia.

sarasas_2_skaicius([],Z,Z).

des_skaic(Sarasas, Skaicius):-
	reverse(Sarasas, PerverstasSarasas, []),
	sarasas_2_skaicius(PerverstasSarasas, SkaiciusIsSaraso, 0),
	Skaicius is SkaiciusIsSaraso.


 reverse([],Z,Z).

 reverse([H|T],Z,Acc) :- reverse(T,Z,[H|Acc]).
/*-------Trecia-------------*/
/*sarašas R - pirmuju duoto sarašo S   K elementu sarašas.
	pirmieji([a,b,c,d,e],3,R).*/
pirmieji(Sarasas, Kiekis, NaujasSarasas) :-
    length(NaujasSarasas, Kiekis),
    append(NaujasSarasas, _, Sarasas).

/*---------Ketvirta------------------*/
/*Saraše S yra K vienas po kito einanciu vienodu elementu E
	kart([a,a,c,a,b,b,b,b,a,g],4,b).*/
lygu(X,X).
kartSim([SarasasPradzia|SarasasLikutis], Kiekis, Simbolis):-
	KiekisN is Kiekis -1,
	KiekisN =:=0,
	lygu(SarasasPradzia, Simbolis);
	KiekisN is Kiekis -1,
	lygu(SarasasPradzia, Simbolis),
	kartSim(SarasasLikutis, KiekisN, Simbolis).

kart([SarasasPradzia|SarasasLikutis], Kiekis, Simbolis):-
	lygu(SarasasPradzia, Simbolis),
	kartSim([SarasasPradzia|SarasasLikutis], Kiekis, Simbolis);
	kart(SarasasLikutis, Kiekis, Simbolis).


