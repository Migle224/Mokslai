function [Y] = edge(X1,X2)
  if(X1 == 0 && X2 == 0)
    Y = 0;
  else
    Y = (1-2*X1*X2)/(2*X1+2*X2);
  endif
endfunction

function [Y] = search(X0, i)
  y0 = edge(X0(1), X0(2));
  x1 = [(X0(1)+i(1)), X0(2)];
  y1 = edge(x1(1), x1(2));
  if y1 < y0
    x2 = [x1(1), (X0(2)+ i(2))];
    y2 = edge(x2(1), x2(2));
    if y2 < y1
      Y = x2;
    else  
      Y = x1;
    endif
  else
    x2 = [X0(1), (X0(2)+ i(2))];
    y2 = edge(x2(1), x2(2));
    if y2 < y0
      Y = x2;
    else
      Y = X0;
    endif
  endif 
endfunction

function [X, Y, steps, functionCalled] = HukeJive(X0, i, alpha, delta)
  functionCalled = 0;
  steps = 0;
  while (i(1) > delta) && (i(2) > delta)
    x1 = search(X0,i);
    y0 = edge(X0(1), X0(2));
    y1 = edge(x1(1), x1(2));
    functionCalled+=5;
    steps += 10;
    while (y1 < y0) && (y1 > 0)
      x2 = [2*x1(1)-X0(1), 2*x1(2)-X0(2)]; 
      x2 = search(x2,i);
      y2 = edge(x2(1), x2(2));
      %if y2 > 0
        X0 = x1;
        x1 = x2;
        y0 = edge(X0(1), X0(2));
        functionCalled+=5;
        y1 = y2;
      %endif
      plot( X0(1),X0(2), "r");  
      steps += 14;
    endwhile    
    i = [i(1)/alpha, i(2)/alpha];
    steps ++;
  endwhile
  X = X0;
  Y = edge(X0(1), X0(2));
  
endfunction

X0 = edge(0,0);
X1 = edge(1,1);
Xm = edge(0.2, 0.1);

X0t = [0,0];
X1t = [1,1];
Xmt = [0.2, 0.1];

i = [0.01, 0.01];
alpha = 2;
delta = 0.001;

figure (1);
[x0, y0, steps0, functionsCalled0]  = HukeJive(X0t, i, alpha, delta)
figure (2);
[x1, y1, steps1, functionsCalled1]  = HukeJive(X1t, i, alpha, delta)
figure (3);
[xm, ym, stepsm, functionsCalledm]  = HukeJive(Xmt, i, alpha, delta)

%X1p = [0:000.1:1];
%X2p = [0:000.1:1];
%hold on 
%plot({X1p, X2p}, (1-2*X1p.*X2p)/(2*X1p+2*X2p))