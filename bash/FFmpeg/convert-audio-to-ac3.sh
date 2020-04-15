#!/bin/bash

echo "

IN=$1 #input file
OUT=$2 #output file

HEADER="-hide_banner -y -v quiet -stats "



ffmpeg $HEADER -i "${IN}" -codec copy -acodec ac3 "${OUT}"
