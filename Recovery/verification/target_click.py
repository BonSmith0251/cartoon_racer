import ctypes,ctypes.wintypes as w,time,json,pathlib,sys
from PIL import ImageGrab
u=ctypes.windll.user32;u.WindowFromPoint.argtypes=[w.POINT];u.WindowFromPoint.restype=w.HWND;u.GetAncestor.argtypes=[w.HWND,w.UINT];u.GetAncestor.restype=w.HWND;u.SetWindowPos.argtypes=[w.HWND,w.HWND,ctypes.c_int,ctypes.c_int,ctypes.c_int,ctypes.c_int,w.UINT]
v=pathlib.Path(r'D:\Games\CartoonRacerRecon\Recovery\verification');d=json.loads((v/'target-window.json').read_text());h=d['hwnd'];x,y=108+int(sys.argv[1]),131+int(sys.argv[2])
u.ShowWindow(h,5);u.SetWindowPos(h,w.HWND(-1),100,100,1296,759,0x40);time.sleep(.3);assert u.GetAncestor(u.WindowFromPoint(w.POINT(x,y)),2)==h
u.SetCursorPos(x,y)
for i in range(1):
 u.mouse_event(2,0,0,0,0);time.sleep(.1);u.mouse_event(4,0,0,0,0);time.sleep(.4)
time.sleep(3);ImageGrab.grab(bbox=tuple(d['bbox'])).save(v/sys.argv[3]);print('foreground',u.GetForegroundWindow())

