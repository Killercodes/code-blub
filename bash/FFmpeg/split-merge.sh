#!/bin/bash

IN=$1
OUT=$2

if [ "$IN" = "-h" ] || [ "$IN" = "-help" ] || [ "$IN" = "/?" ] 
then
  echo "AV Split Merger"
  echo "program <inputfile> <option> <outputfile>"
  
fi

#ffmpeg -i "${IN}" -af "channelmap=channel_layout=${OP}" "${OUT}"
# Split
ffmpeg -i "${IN}"  -filter_complex "channelsplit=channel_layout=5.1[FL][FR][FC][LFE][SL][SR]" -map "[FL]" front_left.wav -map "[FR]" front_right.wav -map "[FC]" front_center.wav -map "[LFE]" lfe.wav -map "[SL]" back_left.wav -map "[SR]" back_right.wav

# Merge
ffmpeg -i front_left.wav -i front_right.wav -i front_center.wav -i lfe.wav -i back_left.wav -i back_right.wav -filter_complex "[0:a][1:a][2:a][3:a][4:a][5:a]amerge=inputs=6[aout]" -map "[aout]" "${OUT}"


