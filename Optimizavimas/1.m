function [Y] = goal(X)
  a = 0;
  b = 5;
  Y = ((X^2 - a)^2) / b - 1;
endfunction

function [Xmin, Ymin, StepsCount, Fcount] = devide()
  a = 0;
  b = 10;
  StepsCount = 0;
  Xm = (a+b)/2;
  Ym = goal(Xm);
  do  
    L = b-a;
    X1 = a+L/4;
    X2 = b - L/4;
    Y1 = goal(X1);
    Y2 = goal(X2); 
   
    hold on
    plot( X1,Y1, "g");
    hold on
    plot( X2,Y2, "g");
    
    if (Y1 < Ym)
      b = Xm;
      Xm = X1;
      Ym = Y1;
    else
      if(Y2<Ym)
        a = Xm;
        Xm = X2;
        Ym = Y2;
      else
        a = X1;
        b = X2;
      endif  
    endif 
    c = b-a;
    StepsCount ++; 
  until (c < 0.0001)
  Fcount = StepsCount * 2 + 1;
  Xmin = Xm;
  Ymin = Ym;
endfunction

function [Xmin, Ymin, StepsCount, Fcount] = gold()
  a = 0;
  b = 10;
  StepsCount = 0;
  w2 = 0.618;
  w1 = 0.382;
  L = b-a;
  XL = w1*L+a;
  XR = w2*L+a;
  YL = goal (XL);
  YR = goal (XR);
  do
    if (YL > YR)
      a = XL;
      XL = XR;
      YL = YR;
      L = b-a;
      XR = a+L*w2;
      YR = goal(XR);
      plot( XR,YR, "r");
    else
      b = XR;
      XR = XL;
      YR = YL;
      L = b-a;
      XL = a+L*w1;
      YL = goal(XL);
      plot( XL,YL, "r");
    endif    
   StepsCount++;
  until (L < 0.0001) 
  Fcount = StepsCount + 2;
  if(YL < YR)
    Xmin = XL;
    Ymin = YL;
  else
    Xmin = XR;
    Ymin = YR;
  endif  
endfunction

f = goal(2.3608);

[Xmin, Ymin, StepsCount, Fcount] = devide()
[XminG, YminG, StepsCountG, FcountG] = gold()

a =0;
b = 5;

X = [0:000.1:10];
hold on 
plot(X, ((X.^2 - a).^2) / b - 1)


