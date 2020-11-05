import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Meus Favoritos/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Home(props){

    const [infos, setInfos] = useState(props.location.state);
    const [meusFavoritos, setMeusFavoritos] = useState([]);


    const consultarMeusFavoritos = async () => {
        try{
            const resp = await api.consultarMeusFavoritos(infos.idUsuario);
            setMeusFavoritos(resp);
        }
        catch (e){

        }
    }

    const excluirFavorito = async (idAnuncio) => {
        try{
            const resp = await api.excluirFavorito(idAnuncio, infos.idUsuario);
            consultarMeusFavoritos();
        }
        catch (e){

        }
    }

    useEffect(() => {
        consultarMeusFavoritos();
      }, []);

    return(
        <div className="eiei">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Home", state: infos}} ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div>

                <div className="barraPesquisa hihi">
                    <Link to={{pathname:"/Home", state: infos}}>Fazer novas consultas</Link>
                </div>

                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos }}>Meu perfil</Link>
                    <Link class="hihi meio" to={{pathname: "/MeusAnuncios", state: infos}}>Meus Anuncios</Link>
                </div>
                <div>
                    <Link  class="hihi" to="/Anunciar"><button class="botao">Anunciar</button></Link>
                </div>
            </div>


            <div class="tabela1">
                <div className="shit1">
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Titulo</th>
                                <th>Preço</th>
                                <th></th>
                            </tr>
                        </thead>

                        <tbody>
                            {meusFavoritos.map(x =>
                                <tr>
                                    <td><Link to={{ pathname: "/Anuncio", state: {infos, x}}}>{x.titulo}</Link></td>
                                    <td>{x.preco}</td>
                                    {console.log(x)}
                                    <td><button className="oia" onClick={() => excluirFavorito(x.idAnuncio)}>Excluir</button></td>
                                </tr>    
                            )}
                        </tbody>
                    </table>
                </div>
            </div>

            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}