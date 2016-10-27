/*Migle Pucetaite, PS4, 3gr., 1310521, 2užd.: 6B*/
/*Dalyba*/
/*dalinti(6,3,X).*/

dalinti(Dalinys, Dalinys, 1).
dalinti(Dalinys, Daliklis, Dalmuo):- DalinysNaujas is Dalinys-Daliklis,
	DalinysNaujas > 0,
	dalinti(DalinysNaujas, Daliklis, DalmuoNaujas),
	Dalmuo is DalmuoNaujas+1.
