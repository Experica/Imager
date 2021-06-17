## ColorMap in Config for Imager
using Colors,YAML


cs = [RGB(HSL(360*i/255,1,0.5)) for i in 0:255]
cm = Dict("ColorMap"=>map(c->round.(Int,255*[c.r,c.g,c.b]),cs))


YAML.write_file(joinpath(@__DIR__,"colormap.yaml"),cm)
