﻿// <copyright file="AnonymousGroup.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor

open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Interop

/// <summary>
/// An Anonymous Group is used to describe a cluster of people where there is no ready identifier for this cluster, e.g. an ad hoc team.
/// </summary>
type public IAnonymousGroup =
    /// <summary>
    /// The members of an anonymous group are a list of agents.
    /// </summary>
    inherit IGroup<seq<IAgent>>

[<NoEquality;NoComparison>]
type public AnonymousGroup =
    struct
        /// <inheritdoc />
        val Name: option<string>

        /// <inheritdoc />
        val Member: seq<IAgent>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.AnonymousGroup"/> class.
        /// </summary>
        /// <param name="members">The members of this Group. Required.</param>
        /// <param name="display">Name of the Group. Optional.</param>
        new (members, [<Optional;DefaultParameterValue(null)>] ?name) =
            nullArg members "members"
            emptySeqArg members "members"
            invalidOptionalStringArg name "name"
            { Name = name; Member = members }

        override this.ToString() =
            match this.Name with
            | Some name -> sprintf "<%O: Name %A Member %O>" (typeName this) name (seqToString this.Member)
            | None -> sprintf "<%O: Member %O>" (typeName this) (seqToString this.Member)

        member this.ObjectType = (this :> IObject).ObjectType

        interface IAnonymousGroup with
            member this.ObjectType = "Group"
            member this.Member = this.Member
            member this.Name = this.Name
    end
