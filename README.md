pdf_A3to4
==========
A4サイズ、A3サイズが混在しているPDFファイルの各ページを、1ページ1PDFファイルとして出力する。

divide A3 in A4 x 2
----------  
  * A3サイズのページはA4サイズx2に分割し、それぞれを1PDFファイルとして出力。
   - 前提：ページはA4縦、またはA3横とし、幅だけでページのサイズを判断する。
   - 1:A4サイズ
     + A4より小さいものはA4サイズとして判断
     + A3サイズより小さいものは余白付のA4サイズと判断する(誤差20 pixels)
   - 2:A3サイズ
     + A3サイズより大きいものは余白付のA3サイズと判断する
  * その他のサイズはそのまま1PDFファイルとして出力。(keep original page sizeと同様)

keep original page size
----------  
  * ページサイズは変更せず、そのままのサイズで1ページを1PDFファイルとして出力。

