project "spirvCross"
	kind "StaticLib"
	language "C"
	staticruntime "on"
	
	targetdir ("bin/" .. outputdir .. "/%{prj.name}")
	objdir ("bin-int/" .. outputdir .. "/%{prj.name}")

	files
	{
        -- core --
        "GLSL.std.450.h",
        "spirv.hpp",
        "spirv_cfg.hpp",
        "spirv_common.hpp",
        "spirv_cross.hpp",
        "spirv_cross_containers.hpp",
        "spirv_cross_error_handling.hpp",
        "spirv_cross_parsed_ir.hpp",
        "spirv_parser.hpp",
        "spirv_cfg.cpp",
        "spirv_cross.cpp",
        "spirv_cross_parsed_ir.cpp",
        "spirv_parser.cpp",
        --glsl --
        "spirv_glsl.hpp",
        "spirv_glsl.cpp",
        -- hlsl --
        "spirv_hlsl.hpp",
        "spirv_hlsl.cpp",
        -- msl --
        "spirv_msl.hpp",
        "spirv_msl.cpp",
        -- reflect --
        "spirv_reflect.hpp",
        "spirv_reflect.cpp",
        -- util --
        "spirv_cross_util.hpp",
        "spirv_cross_util.cpp",
	}

	includedirs
	{
    }
    
    defines {
        "SPIRV_CROSS_EXCEPTIONS_TO_ASSERTIONS"
    }

	filter "system:windows"
		systemversion "latest"

		filter "configurations:Debug"
		runtime "Debug"
		symbols "on"	-- debug version --

	filter "configurations:Release"
		runtime "Release"
		optimize "on"	-- release version --
