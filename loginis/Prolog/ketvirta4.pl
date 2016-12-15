 % facts about the domain

     squares([cell(a, _), cell(b, _), cell(c, _), cell(d, _),
              cell(e, _), cell(f, _), cell(g, _), cell(h, _),
	      cell(i, _), cell(j, _), cell(k, _), cell(l, _),
	      cell(m, _), cell(n, _), cell(o, _), cell(p, _)]).

     numbers([15,1,14,4,12,6,7,9,8,10,11,5,13,3,2,16]).

     sum_of_row(34).

     generate_square :-
          % retrieve facts about the domain
          squares(Square),
          numbers(Numbers),
          % generate square
          fill_square(Numbers, Square),
          % test square
          test_square(Square),
          % output square
          display_square(Square).


     % 1 boundary condition
     fill_square([], _).
     % 2 recursive condition
     fill_square([Number|Tail], Cells) :-
          member2(cell(_, Number), Cells),
          fill_square(Tail, Cells).


     test_square([cell(a, Cell_a), cell(b, Cell_b), cell(c, Cell_c), cell(d, Cell_d),
                  cell(e, Cell_e), cell(f, Cell_f), cell(g, Cell_g), cell(h, Cell_h),
                  cell(i, Cell_i), cell(j, Cell_j), cell(k, Cell_k), cell(l, Cell_l),
		  cell(m, Cell_m), cell(n, Cell_n), cell(o, Cell_o), cell(p, Cell_p)]) :-
          sum_of_row(Sum),
          % test rows
          Sum is Cell_a + ((Cell_b + Cell_c) + Cell_d),
	  Sum is Cell_e + ((Cell_f + Cell_g) + Cell_h),
	  Sum is Cell_i + ((Cell_j + Cell_k) + Cell_l),
	  Sum is Cell_m + ((Cell_n + Cell_o) + Cell_p),
	  % test columns
	  Sum is Cell_a + ((Cell_e + Cell_i) + Cell_m),
	  Sum is Cell_b + ((Cell_f + Cell_j) + Cell_n),
	  Sum is Cell_c + ((Cell_g + Cell_k) + Cell_o),
	  Sum is Cell_d + ((Cell_h + Cell_l) + Cell_p),
          % test diagonals
	  Sum is Cell_a + ((Cell_f + Cell_k) + Cell_p),
	  Sum is Cell_d + ((Cell_g + Cell_j) + Cell_m).


     display_square([cell(a, Cell_a), cell(b, Cell_b), cell(c, Cell_c), cell(d, Cell_d),
                  cell(e, Cell_e), cell(f, Cell_f), cell(g, Cell_g), cell(h, Cell_h),
                  cell(i, Cell_i), cell(j, Cell_j), cell(k, Cell_k), cell(l, Cell_l),
		  cell(m, Cell_m), cell(n, Cell_n), cell(o, Cell_o), cell(p, Cell_p)]) :-
          tab(10),
          writeln('-----------------'),
          tab(10),
          write('| '),
          write(Cell_a),
          write(' | '),
          write(Cell_b),
          write(' | '),
          write(Cell_c),
	  write(' | '),
          write(Cell_d),
          writeln(' |'),
          tab(10),
          writeln('-----------------'),
          tab(10),
          write('| '),
          write(Cell_e),
          write(' | '),
          write(Cell_f),
          write(' | '),
          write(Cell_g),
	  write(' | '),
          write(Cell_h),
          writeln(' |'),
          tab(10),
          writeln('-----------------'),
          tab(10),
          write('| '),
          write(Cell_i),
          write(' | '),
          write(Cell_j),
          write(' | '),
          write(Cell_k),
	  write(' | '),
          write(Cell_l),
          writeln(' |'),
          tab(10),
          writeln('-----------------'),
          tab(10),
          write('| '),
          write(Cell_m),
          write(' | '),
          write(Cell_n),
          write(' | '),
          write(Cell_o),
	  write(' | '),
          write(Cell_p),
          writeln(' |'),
          tab(10),
          writeln('-----------------').



     % utilities

     % member/2
     % 1 boundary condition
     member2(Elem, [Elem|_]).
     % 2
     member2(Elem, [_|Tail]) :-
          member2(Elem, Tail).

     % writeln/1
     writeln(Arg) :-
          write(Arg),
          nl.
