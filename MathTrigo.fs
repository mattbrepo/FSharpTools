module Sofa.MathTrigo

open Sofa.Math

//REGOLE TRIGONOMETRICHE
// 
//                       beta
//                      .
//             b    .   |
//              .       | c
//          .           |
//  gamma --------------- alfa
//              a      

/// CALCOLO LATO a IN GRADI E RADIANTI
let tri_a_d c gamma_d = c / sin_d(gamma_d)
let tri_a_r c gamma_r = c / sin_r(gamma_r)

