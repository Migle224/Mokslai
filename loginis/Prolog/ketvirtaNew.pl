/*  File:    fifteen_puzzle.pl
    Author:  Carlo,,,
    Created: Jul  9 2014
    Purpose: solve 15-puzzle
*/

:- module(fifteen_puzzle,
      [fifteen_puzzle/3
      ]).

:- use_module(library(nb_set)).
:- use_module(library(plunit)).

%%  fifteen_puzzle(+Target, +Start, -Moves) is nondet.
%
%   public interface to solver
%
fifteen_puzzle(Target, Start, Moves) :-
    empty_nb_set(Empty),
    solve(Empty, Target, Start, Moves).

%%  -- private here --

solve(_, Target, Target, []) :-
    !.
solve(S, Target, Current, [Move|Ms]) :-
    add_to_seen(S, Current),
    setof(Dist-MoveStep-Update,
          (  get_move(Current, Position, MoveStep),
         apply_move(Current, Position, MoveStep, Update),
         distance(Target, Update, Dist)
          ), Moves),
    member(_-Move-U, Moves),
    solve(S, Target, U, Ms).

%%  get_move(+Board, +P, -Q) is semidet
%
%   based only on coords, get next empty cell
%
get_move(Board, Position, Q) :-
    nth0(Position, Board, 0),
    coord(Position, Row, Column),
    (   Row < 3, Q is Position + 4
    ;   Row > 0, Q is Position - 4
    ;   Column < 3, Q is Position + 1
    ;   Column > 0, Q is Position - 1
    ).

%%  apply_move(+Current, +P, +M, -Update)
%
%   swap elements at position P and M
%
apply_move(Current, Position, Move, Update) :-
    assertion(nth0(Position, Current, 0)), % constrain to this application usage
    ( Position > Move -> (F,S) = (Move,Position) ; (F,S) = (Position,Move) ),
    nth0(S, Current, Sv, A),
    nth0(F, A, Fv, B),
    nth0(F, C, Sv, B),
    nth0(S, Update, Fv, C).

%%  coord(+P, -R, -C)
%
%   from linear index to row, col
%   size fixed to 4*4
%
coord(Position, Row, Column) :-
    Row is Position // 4,
    Column is Position mod 4.

%%  distance(+Current, +Target, -Dist)
%
%   compute Manatthan distance between equals values
%
distance(Current, Target, Dist) :-
    aggregate_all(sum(D),
              (   nth0(Position, Current, N), coord(Position, Rowp, Columnp),
              nth0(Q, Target, N), coord(Q, Rq, Cq),
              D is abs(Rowp - Rq) + abs(Columnp - Cq)
              ), Dist).

%%  add_to_seen(+S, +Current)
%
%   fail if already in, else store
%
add_to_seen(S, L) :-
    %term_to_atom(L, A),
    findall(C, (nth0(I, L, D), C is D*10^I), Cs),
    sum_list(Cs, A),
    add_nb_set(A, S, true).

:- begin_tests(fifteen_puzzle).

show_square(R) :-
    findall(Row, (between(1,4,_), length(Row, 4)), Rows),
    append(Rows, R),
    nl, maplist(show_row, Rows).
show_row(R) :-
    format('~t~d~3+~t~d~3+~t~d~3+~t~d~3+~n', R).

show_solution(P, []) :-
    show_square(P).
show_solution(P, [M|Ms]) :-
    show_square(P),
    nth0(C, P, 0),
    apply_move(P, C, M, U),
    show_solution(U, Ms).

target(  [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,0]).

start(0, [1,2,3,4,5,6,7,8,9,10,11,12,0,13,14,15]).
start(1, [1,2,3,4,5,6,7,8,9,11,10,12,0,13,14,15]).

test(0) :- runtest(0).
test(1) :- runtest(1).

runtest(N) :-
    target(T),
    start(N, S),
    fifteen_puzzle(T, S, R),
    format('solution of ~d: ~w~n', [N, R]),
    show_solution(S, R).

:- end_tests(fifteen_puzzle).
