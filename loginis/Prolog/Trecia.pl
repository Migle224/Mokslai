/*1.6 2.7 3.5 4.1*/
/*1.6  tr_suma(Sar,Sum): duotajame sara�e Sar galima rasti tris i� eiles einancius skaicius, kuriu suma lygi Sum.*/
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
/*Skaicius Skaic atitinka duota de�imtainiu skaitmenu sara�a Sar.
 des_skaic ([1,9,8,5],1985).*/
string_to_list_of_characters(String, Characters) :-
    name(String, Xs),
    maplist( number_to_character,
       Xs, Characters ).

number_to_character(Number, Character) :-
    name(Character, [Number]).

des_skaic(Sarasas, Skaicius):-
	string_to_list_of_characters(Skaicius, SkaiciausSarasas),
	lygink(Sarasas, SkaiciausSarasas).

lygink([PirmaPradzia|PirmasLikutis], [AntraPradzia|AntrasLikutis]):-
	PirmaPradzia =:= AntraPradzia,
	lygink(PirmasLikutis, AntrasLikutis).

lygink([],[]).
/*-------Trecia-------------*/
/*sara�as R - pirmuju duoto sara�o S   K elementu sara�as.
	pirmieji([a,b,c,d,e],3,[a,b,c]).*/
pirmieji([PirmasPradzia|PirmasLikutis], Kiekis, [AntrasPradzia|AntrasLikutis]):-
                            KiekisN is Kiekis-1,
			    KiekisN =:= 0,
			    lygu(PirmasPradzia,AntrasPradzia);
			    KiekisN is Kiekis-1,
			    lygu(PirmasPradzia,AntrasPradzia),
			    pirmieji(PirmasLikutis, KiekisN, AntrasLikutis).

lygu(X,X).
/*---------Ketvirta------------------*/
/*Sara�e S yra K vienas po kito einanciu vienodu elementu E
	kart([a,a,c,a,b,b,b,b,a,g],4,b).*/
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


