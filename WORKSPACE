workspace(name = "greetings", managed_directories = {"@npm": ["node_modules"]})

load("@bazel_tools//tools/build_defs/repo:http.bzl", "http_archive")
load("@bazel_tools//tools/build_defs/repo:git.bzl", "git_repository")

git_repository(
    name = "io_bazel_rules_dotnet",
    remote = "https://github.com/bazelbuild/rules_dotnet",
    commit = "e6415707f7e26756456d2473b9b22dfbeff66171",
)

http_archive(
    name = "build_bazel_rules_svelte",
    url = "https://github.com/thelgevold/rules_svelte/archive/0.15.zip",
    strip_prefix = "rules_svelte-0.15",
    sha256 = "1b04eb08ef80636929d152bb2f2733e36d9e0b8ad10aca7b435c82bd638336f5"
) 

http_archive(
    name = "build_bazel_rules_nodejs",
    sha256 = "591d2945b09ecc89fde53e56dd54cfac93322df3bc9d4747cb897ce67ba8cdbf",
    urls = ["https://github.com/bazelbuild/rules_nodejs/releases/download/1.2.0/rules_nodejs-1.2.0.tar.gz"],
)

load("@build_bazel_rules_nodejs//:index.bzl", "node_repositories", "yarn_install")

yarn_install(
    name = "npm",
    package_json = "//:package.json",
    yarn_lock = "//:yarn.lock",
)

load("@io_bazel_rules_dotnet//dotnet:deps.bzl", "dotnet_repositories")

dotnet_repositories()

load(
    "@io_bazel_rules_dotnet//dotnet:defs.bzl",
    "core_register_sdk",
    "dotnet_register_toolchains",
    "dotnet_repositories_nugets",
   
)

dotnet_register_toolchains()

dotnet_repositories_nugets()

core_register_sdk(
    "v3.1.100",
)

core_register_sdk(
    "v3.1.100",
    name = "core_sdk",
)

load("@build_bazel_rules_svelte//:defs.bzl", "rules_svelte_dependencies")
rules_svelte_dependencies()