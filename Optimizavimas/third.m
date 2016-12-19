c = [2, -3, 0, -5]';
A = [ -1, 1, -1, -1;
     2, 4, 0, 0;
     0, 0, 1, -1];
     
b = [8, 10, -3]';
lb = [0, -Inf, 0, -Inf]';
ub = [];
ctype = "SSL";
vartype = "IIII";
s = 1;

param.itlim = 100;

[xmin, fmin, status, extra] = glpk (c, A, b, lb, ub, ctype, vartype, s, param)


b = [5, 2, 1]';

[xmin, fmin, status, extra] = glpk (c, A, b, lb, ub, ctype, vartype, s, param)


c = [8,10,-3]';
A = [ -1, 2, 0;
     1, 4, 0;
     -1, 0, 1,
     -1, 0, -1];
     
b = [2, -3, 0, -5]';
lb = [-Inf, -Inf, 0]';
ub = [];
ctype = "USUS";
vartype = "III";
s = -1;

param.itlim = 1000;

[xmin, fmin, status, extra] = glpk (c, A, b, lb, ub, ctype, vartype, s, param)
