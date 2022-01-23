## NcCopy: 
Reads the original program in g-code (*.nc) and creates the desired number of copies of the X and Y axis.

**Syntax:**  
*nccopy.exe [inputfile] [number of copies on the X-axis (int)] [number of copies on the Y-axis (int)] [copy spacing (decimal)]*

**example:**  
*nccopy.exe part1.nc 2 2 10*

**Result:**  
Generation of a program which contains 4 copies of the original program part1.nc with a 2x2 layout and a spacing of 10 between them.

## WinNcCopy:  
So far, it only reads the program in g-code (*.nc)  and renders it on a form.  
To view it, run WinNcCopy and in the dialog box select the desired file with the extension nc.  
Viewed programs are automatically scaled to fit the viewing window.
