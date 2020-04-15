#!/bin/bash

echo "Convert Movie 2.0 ch to Dolby 5.1 ch"


INPUT=$1

OUTPUT=$2


ffmpeg -i "${INPUT}" -filter_complex "[0:a]pan=5.1(side)|FL = FL|FR = FR|FC < 0.5*FL + 0.5*FR|LFE < FL+FR|SL = FL|SR = FR[a]" -map 0 -map -0:a -map "[a]" -c copy -c:a ac3 "${OUTPUT}"
