#!/bin/bash

echo "

IN=$1 #input file
OUT=$2 #output file


ffmpeg -i "${IN}" -codec copy -acodec ac3 "${OUT}"
