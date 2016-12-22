function [Y] = goal(X1,X2,X3)
  Y = X1*X2*X3;
endfunction

function [Y] = g(X1,X2,X3,r)
  Y = (2*X1*X2+2*X1*X3+2*X2*X3 - 1)/r;
endfunction
  
function [Y] = search(X0, i)
  y0 = goal(X0(1), X0(2), X0(3));
  x1 = [(X0(1)+i(1)), X0(2), X0(3)];
  y1 = goal(x1(1), x1(2), x1(3));
  if y1 >= y0
    x2 = [x1(1), (X0(2)+ i(2)), x1(3)];
    y2 = goal(x2(1), x2(2), x2(3));
    if y2 >= y1
      x3 = [x2(1),x2(2),(x2(3)+i(3))];
      y3 = goal(x3(1), x3(2), x3(3));
      if y3 >= y2
        Y = x3;
      else
        Y = x2;
      endif     
    else
      x3 = [x2(1),x1(2),(x2(3)+i(3))];
      y3 = goal(x3(1), x3(2), x3(3));  
      if y3 >= y1
        Y = x3;
      else
        Y = x1;
      endif 
    endif
  else
    x2 = [X0(1), (X0(2)+ i(2)), X0(3)];
    y2 = goal(x2(1), x2(2), x2(3));
    if y2 >= y0
      x3 = [x2(1),x2(2),(x2(3)+i(3))];
      y3 = goal(x3(1), x3(2), x3(3));
      if y3 >= y2
        Y = x3;
      else
        Y = x2;
      endif     
    else
      x3 = [X0(1),X0(2),(X0(3)+i(3))];
      y3 = goal(x3(1), x3(2), x3(3));
      if y3 >= y0
        Y = x3;
      else
        Y = X0;
      endif     
    endif
  endif 
endfunction

function [X, Y, steps, functionCalled] = HukeJive(X0, i, alpha, delta)
  functionCalled = 0;
  steps = 0;
  while (i(1) > delta) && (i(2) > delta)
    x1 = search(X0,i);
    y0 = goal(X0(1), X0(2), X0(3));
    y1 = goal(x1(1), x1(2), x1(3));
    functionCalled+=5;
    steps += 10;
    while (y1 >= y0) && (y1 >= 0) && (g(X0(1), X0(2), X0(3),(1/functionCalled)) < 0) && (functionCalled < 10000)
      x2 = [2*x1(1)-X0(1), 2*x1(2)-X0(2), 2*x1(3)-X0(3)]; 
      x2 = search(x2,i);
      y2 = goal(x2(1), x2(2), x2(3));
      %if y2 > 0
        X0 = x1;
        x1 = x2;
        y0 = goal(X0(1), X0(2), X0(3));
        functionCalled+=5;
        y1 = y2;
      %endif
      %plot( X0(1),X0(2), "r");  
      steps += 14;
    endwhile    
    i = [i(1)/alpha, i(2)/alpha, i(3)/alpha];
    steps ++;
  endwhile
  X = X0;
  Y = goal(X0(1), X0(2), X0(3));
  
endfunction

X0 = goal(0,0,0);
X1 = goal(1,1,1);
Xm = goal(0.5, 0.2, 0.1);

X0t = [0,0,0];
X1t = [1,1,1];
Xmt = [0.5, 0.2, 0.1];
Xm1 = [0.1, 0.1, 0.1];

i = [0.001, 0.001, 0.001];
alpha = 2;
delta = 0.0001;


[x0, y0, steps0, functionsCalled0]  = HukeJive(X0t, i, alpha, delta)

[x1, y1, steps1, functionsCalled1]  = HukeJive(X1t, i, alpha, delta)

[xm, ym, stepsm, functionsCalledm]  = HukeJive(Xmt, i, alpha, delta)


