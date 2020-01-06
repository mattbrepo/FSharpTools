module Sofa.Math

/// FATTORIALE
//let rec factorial n = if n=0 then 1 else n * factorial (n-1)
let factorial n = [1..n] |> List.reduce (*)

/// MASSIMO COMUNE DIVISORE
let rec mcd a b =                       // notice: 2 parameters separated by spaces
    if a=0 then b
    elif a<b then mcd a (b-a)           // notice: 2 arguments separated by spaces
    else mcd (a-b) b

/// QUADRATO
let sqr x = x*x

/// CUBO
let cube x = x*x*x

/// POW
let pow b exp = System.Math.Pow(b, exp)

/// RADICE QUADRATA
let sqrt x = System.Math.Sqrt(x)

/// ABS FLOAT
let fabs(x:float) = System.Math.Abs(x)

/// ABS FLOAT
let dabs(x:double) = System.Math.Abs(x)

/// P GRECO
let pi = System.Math.PI;

/// DA GRADI A RADIANTI 
let degree_to_radiant d = d * (pi / 180.0)

/// DA RADIANTI A GRADI
let radiant_to_degree r = r * (180.0 / pi)

/// SENO IN RADIANTI
let sin_r r = System.Math.Sin(r)

/// SENO IN GRADI
let sin_d d = 
    let r = degree_to_radiant(d)
    sin_r r

/// COSENO IN RADIANTI
let cos_r r = System.Math.Cos(r)

/// COSENO IN GRADI
let cos_d d = 
    let r = degree_to_radiant(d)
    cos_r r

/// TANGENTE IN RADIANTI
let tan_r r = System.Math.Tan(r)

/// TANGENTE IN GRADI
let tan_d d = 
    let r = degree_to_radiant(d)
    tan_r r

/// ARCOSENO IN RADIANTI
let asin_r x = System.Math.Asin(x)

/// ARCOSENO IN GRADI
let asin_d x = 
    let r = asin_r x
    radiant_to_degree r