c = [2, -3, 0, -5]';
A = [ -1, 1, -1, -1;
     2, 4, 0, 0;
     0, 0, -1, 1];
     
b = [8, 10, 3]';
lb = [0, -Inf, 0, -Inf]';
ub = [];
ctype = "SSU";
vartype = "IIII";
s = 1;

param.itlim = 100;

[xmin, fmin, status, extra] = glpk (c, A, b, lb, ub, ctype, vartype, s, param)


b = [5, 2, 1]';

[xmin, fmin, status, extra] = glpk (c, A, b, lb, ub, ctype, vartype, s, param)


c = [-1, 2, 0, 1, 0]';
A = [ -1, 2, 0, 1, 0;
     1, 4, 0, 0, 0;
     -1, 0, -1, 0, 1,
     -1, 0, 1, 0, 0];
     
b = [2, -3, 0, -5]';
lb = [-Inf, -Inf, -Inf, -Inf, -Inf]';
ub = [];
ctype = "SSSS";
vartype = "IIIII";
s = -1;

param.itlim = 100;

[xmin, fmin, status, extra] = glpk (c, A, b, lb, ub, ctype, vartype, s, param)
